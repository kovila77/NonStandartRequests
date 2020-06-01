using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TranslationColumns;

namespace NonStandartRequests
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //var tf = new fTranslationColumns(fTranslationColumns.FormType.NeedExit) { Visible = false };
            //Application.Run(tf);
            //tf.Dispose();
            MessageBox.Show("Введите названия столбцов. После завершения редактирования закройте окно для продолжения");

            var tf = new fTranslationColumns(fTranslationColumns.FormType.NeedChanges);
            Application.Run(tf);
            tf.Dispose();

            Application.Run(new fNonStandartRequests());
        }
    }
}
