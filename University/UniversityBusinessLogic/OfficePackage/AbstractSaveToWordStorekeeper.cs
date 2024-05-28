using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityBusinessLogic.OfficePackage.HelperModels;
using UniversityBusinessLogic.OfficePackage.HelperEnums;

namespace UniversityBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToWordStorekeeper
    {
        public void CreateDoc(WordInfoStorekeeper info)
        {
            CreateWord(info);

            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)> { (info.Title, new WordTextProperties { Bold = true, Size = "24", }) },
                TextProperties = new WordTextProperties
                {
                    Size = "24",
                    JustificationType = WordJustificationType.Center
                }
            });

            foreach (var discipline in info.Disciplines)
            {
                CreateParagraph(new WordParagraph
                {
                    Texts = new List<(string, WordTextProperties)>
                    {
                        ("Teacher №" + discipline.TeacherId.ToString() + "  -  " + discipline.TeacherName, new WordTextProperties {Size = "24", Bold=true})
                    },
                    TextProperties = new WordTextProperties
                    {
                        Size = "24",
                        JustificationType = WordJustificationType.Both
                    }
                });
                foreach (var assembly in discipline.StudentDisciplines)
                {
                    /*if (!string.IsNullOrEmpty(assembly.AssemblyName) && !string.IsNullOrEmpty(assembly.AssemblyCategory) && assembly.AssemblyPrice != 0)
                    {
                        CreateParagraph(new WordParagraph
                        {
                            Texts = new List<(string, WordTextProperties)> {
						(assembly.AssemblyName + " - ", new WordTextProperties {  Size = "24" }),
                        (assembly.AssemblyCategory + " - ", new WordTextProperties { Size = "24" }),
                        (assembly.AssemblyPrice.ToString(), new WordTextProperties { Size = "24" })
                        },
                            TextProperties = new WordTextProperties
                            {
                                Size = "24",
                                JustificationType = WordJustificationType.Both
                            }
                        });
                    }*/

                }
            }
            SaveWord(info);
        }

        /// <summary>
        /// Создание doc-файла
        /// </summary>
        /// <param name="info"></param>
        protected abstract void CreateWord(WordInfoStorekeeper info);

        /// <summary>
        /// Создание абзаца с текстом
        /// </summary>
        /// <param name="paragraph"></param>
        /// <returns></returns>
        protected abstract void CreateParagraph(WordParagraph paragraph);

        /// <summary>
        /// Сохранение файла
        /// </summary>
        /// <param name="info"></param>
        protected abstract void SaveWord(WordInfoStorekeeper info);
    }
}
