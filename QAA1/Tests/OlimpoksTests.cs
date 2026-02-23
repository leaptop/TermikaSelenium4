using NUnit.Framework;
using TermikaSelenium4.Pages;

namespace TermikaSelenium4.Tests
{
    public class OlimpoksTests : BaseTest
    {
        private OlimpoksBasePO _olimpoksBasePO;
        private CoursesCatalogPO _coursesCatalogPO;
        private CategoryPO _categoryPO;
        [SetUp]
        public void SetUp()
        {
            Driver.Navigate().GoToUrl("https://olimpoks.ru/");
            Driver.Manage().Window.Maximize();
            _olimpoksBasePO = new OlimpoksBasePO(Driver);
            _olimpoksBasePO.HandleTelegramPopup();
        }
        [Test]
        public void TsetFileSaving()
        {
            // string relativePath = Path.Combine("..", "..", "output.txt");
            //string relativePath = Path.Combine("..", "..", "output.txt");
            //string text = "Привет, мир!";
            //// string path = "test.txt";
            //System.IO.File.WriteAllText(relativePath, text); // Создает или перезаписывает [


            //string newText = "Новая строка" + Environment.NewLine;
            //System.IO.File.AppendAllText(relativePath, newText); // Добавляет [5]


            string testDirectory = TestContext.CurrentContext.TestDirectory;
            string projectDirectory = Directory.GetParent(testDirectory).Parent.Parent.FullName;

            // 2. Формируем путь к папке Output
            string outputDir = Path.Combine(projectDirectory, "Output");

            // 3. Создаём папку, если её ещё нет (метод CreateDirectory ничего не делает, если папка существует)
            Directory.CreateDirectory(outputDir);

            // 4. Формируем полный путь к файлу (например, courses.txt)
            string filePath = Path.Combine(outputDir, "courses_output.txt");

            // 5. Сохраняем данные
            // Предположим, courses — это список строк
            //le.WriteAllLines(filePath, courses.Select(c => c.ToString()));
            List<String> courses = ["fi\n", "fa"];
            File.WriteAllLines(filePath, courses.Select(c => c.ToString()));


            // Thread.Sleep(700000);
        }

        [Test]
        //[Repeat(10)]
        public void TestSolutionsClicking()
        {
            _coursesCatalogPO = new CoursesCatalogPO(Driver);
            _olimpoksBasePO.ClickSolutionsMenuElement();
            _olimpoksBasePO.ClickLaborProtectionMenuItem();
            _coursesCatalogPO.ClickWorkersCheckBox();
            _coursesCatalogPO.ClickBriefingLearningCheckBox();
            _coursesCatalogPO.ClickDetailsButtonByCategory("Видеоинструктажи");
            _categoryPO = new CategoryPO(Driver);




        }

    }
}
