using ClosedXML.Excel;
using DevExpress.Utils.CommonDialogs.Internal;
using DocumentFormat.OpenXml.CustomProperties;
using Faq_Wpf_Mvvm.Models;
using Microsoft.EntityFrameworkCore;
using Ookii.Dialogs.Wpf;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WinForms = System.Windows.Forms;

namespace Faq_Wpf_Mvvm.ViewModels
{
    public class ProfileViewModel : StaticViewModel
    {
        public ProfileViewModel()
        {
            rand = new Random();
            NameTextBlock = Service.ClientSession.FirstName;
            SurnameTextBlock = Service.ClientSession.SecondName;
            LastNameTextBlock = Service.ClientSession.LastName;
            LoginTextBlock = Service.ClientSession.Login;
            TaskCountGet = Service.db.TaskXes.Count(x => x.UsersGetId == Service.ClientSession.Id);
            TaskCountSet = Service.db.TaskXes.Count(x => x.UsersSetId == Service.ClientSession.Id);
            ListOfTasks = new ObservableCollection<TaskX>(Service.db.TaskXes.Where(x => x.UsersGetId == Service.ClientSession.Id).Include(x => x.Status).Include(x => x.UsersSet));
        }
        private Random rand { get; set; }
        private ObservableCollection<TaskX> _listOfTasks;
        public ObservableCollection<TaskX> ListOfTasks
        {
            get { return _listOfTasks; }
            set { _listOfTasks = value; OnPropertyChanged(); }
        }
        public string NameTextBlock { get; set; }
        public string SurnameTextBlock { get; set; }
        public string LastNameTextBlock { get; set; }
        public string LoginTextBlock { get; set; }
        private int _taskCountGet;
        public int TaskCountGet
        {
            get { return _taskCountGet; }
            set { _taskCountGet = value; OnPropertyChanged(); }
        }
        private int _taskCountSet;
        public int TaskCountSet
        {
            get { return _taskCountSet; }
            set { _taskCountSet = value; OnPropertyChanged(); }
        }

        private RelayCommand _createReport;
        public RelayCommand CreateReport => _createReport ?? (_createReport = new RelayCommand(x =>
        {
            int height = 50;
            int width = 0;
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Calibri", 14);
            foreach (var item in ListOfTasks)
            {
                gfx.DrawString(item.Date.ToString(), font, XBrushes.Black, new XRect(width, height, 0, 0), XStringFormats.BaseLineLeft);
                width = width + 120;
                gfx.DrawString(item.Title.ToString(), font, XBrushes.Black, new XRect(width, height, 0, 0), XStringFormats.BaseLineLeft);
                height = height + 20;
                width = 0;
                gfx.DrawString($"Описание: {item.Description}", font, XBrushes.Black, new XRect(width, height, 0, 0), XStringFormats.BaseLineLeft);
                height = height + 15;
                width = 0;
                gfx.DrawString($"Ответ: {item.Answer}", font, XBrushes.Black, new XRect(width, height, 0, 0), XStringFormats.BaseLineLeft);
                height = height + 23;
                width = 0;
            }
            
            using (XLWorkbook workbook = new XLWorkbook())
            {
                string name = "Report" + rand.Next().ToString();
                IXLWorksheet? worksheet = workbook.Worksheets.Add("Report sheet");
                worksheet.Column("B").CellsUsed().SetDataType(XLDataType.DateTime);
                worksheet.Column("C").CellsUsed().SetDataType(XLDataType.Text);
                worksheet.Column("D").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
                worksheet.Column("B").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
                int x1 = 2;
                int y1 = 2;
                int AllSum = 0;
                worksheet.Cell(1, 1).Value = Convert.ToString(Service.ClientSession.Login);
                worksheet.Cell(1, 2).Value = Convert.ToString("Дата");
                worksheet.Cell(1, 2).Style.Border.BottomBorder = XLBorderStyleValues.Thick;
                worksheet.Cell(1, 3).Value = Convert.ToString("Описание");
                worksheet.Cell(1, 3).Style.Border.BottomBorder = XLBorderStyleValues.Thick;
                worksheet.Cell(1, 4).Value = Convert.ToString("Ответ");
                worksheet.Cell(1, 4).Style.Border.BottomBorder = XLBorderStyleValues.Thick;
                foreach (var item in ListOfTasks)
                {
                    worksheet.Cell(y1, x1).Value = item.Date;
                    y1 += 1;
                }
                y1 = 2;
                x1 = 3;
                foreach (var item in ListOfTasks)
                {
                    worksheet.Cell(y1, x1).Value = item.Description;
                    y1 += 1;
                }
                y1 = 2;
                x1 = 4;
                foreach (var item in ListOfTasks)
                {
                    worksheet.Cell(y1, x1).Value = item.Answer;
                    y1 += 1;
                }
                worksheet.Cell(y1, 2).Value = Convert.ToString(AllSum);
                worksheet.Column("B").AdjustToContents();
                worksheet.Column("C").AdjustToContents();
                worksheet.Column("D").AdjustToContents();
                worksheet.Column("A").AdjustToContents();
                VistaFolderBrowserDialog dlg = new VistaFolderBrowserDialog();
                dlg.ShowNewFolderButton = true;
                string path = null;
                if (dlg.ShowDialog() == true)
                {
                    path = dlg.SelectedPath;
                }
                if (path != null)
                {
                    workbook.SaveAs($"{path}\\{name}.xlsx");
                    string filename = path + "\\" + "Report.pdf";
                    document.Save(filename);
                }
                
            }
        }));
    }
}
