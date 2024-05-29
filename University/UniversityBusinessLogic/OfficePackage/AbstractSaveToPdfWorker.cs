﻿using UniversityBusinessLogic.OfficePackage.HelperEnums;
using UniversityBusinessLogic.OfficePackage.HelperModels;

namespace UniversityBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToPdfWorker
    {
        public void CreateDoc(PdfInfoWorker info)
        {
            CreatePdf(info);
            CreateParagraph(new PdfParagraph { Text = info.Title, Style = "NormalTitle", ParagraphAlignment = PdfParagraphAlignmentType.Center });
            CreateParagraph(new PdfParagraph { Text = $"с {info.DateFrom.ToShortDateString()} по {info.DateTo.ToShortDateString()}", Style = "Normal", ParagraphAlignment = PdfParagraphAlignmentType.Center });

            CreateTable(new List<string> { "2cm", "3cm", "6cm", "3cm", "4 cm" });

            CreateRow(new PdfRowParameters
            {
                Texts = new List<string> { "Номер", "План обучения", "Студент - дисциплина" },
                Style = "NormalTitle",
                ParagraphAlignment = PdfParagraphAlignmentType.Center
            });

            foreach (var item in info.PlanOfStudyAndStudent)
            {
                CreateRow(new PdfRowParameters
                {
                    Texts = new List<string> { item.Id.ToString(), item.PlanOfStudyName, string.Join(", ", item.StudentsAndDisciplines.Select(sd => $"{sd.Student} - {sd.Discipline}")) },
                    Style = "Normal",
                    ParagraphAlignment = PdfParagraphAlignmentType.Left
                });
            }
            SavePdf(info);
        }

        /// <summary>
		/// Создание doc-файла
		/// </summary>
		/// <param name="info"></param>
        protected abstract void CreatePdf(PdfInfoWorker info);

        /// <summary>
        /// Создание параграфа с текстом
        /// </summary>
        /// <param name="title"></param>
        /// <param name="style"></param>
        protected abstract void CreateParagraph(PdfParagraph paragraph);

        /// <summary>
        /// Создание таблицы
        /// </summary>
        /// <param name="title"></param>
        /// <param name="style"></param>
        protected abstract void CreateTable(List<string> columns);

        /// <summary>
        /// Создание и заполнение строки
        /// </summary>
        /// <param name="rowParameters"></param>
        protected abstract void CreateRow(PdfRowParameters rowParameters);

        /// <summary>
		/// Сохранение файла
		/// </summary>
		/// <param name="info"></param>
        protected abstract void SavePdf(PdfInfoWorker info);
    }
}
