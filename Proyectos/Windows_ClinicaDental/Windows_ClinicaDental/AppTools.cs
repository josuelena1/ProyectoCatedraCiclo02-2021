using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Extra libraries
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Windows_ClinicaDental
{
    public class infoBar
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public InfoBarSeverity Severity { get; set; }

        public static void CreateInfoBar(infoBar info)
        {
            var notifBar = MainPage.Current.notifBar;
            if (notifBar.IsOpen) notifBar.IsOpen = false;
            notifBar.Title = info.Title;
            notifBar.Content = info.Message + "\n";
            notifBar.Severity = info.Severity;
            notifBar.IsOpen = true;
        }
    }

    public class ContentDiag
    {
        public static ContentDialogResult result;
        public string Title { get; set; }
        public string Content { get; set; }
        public bool PrimBtnEnable { get; set; }
        public bool SecBtnEnable { get; set; }
        public string PrimBtnText { get; set; }
        public string SecBtnText { get; set; }
        public string CloseBtnText { get; set; }
        public int DefaultBtn { get; set; }
        /*
         * 0 for Close
         * 1 for Primary
         * 2 for Secondary
         */

        public static async Task<ContentDialogResult> DiagOpen(ContentDiag diag)
        {
            ContentDialog dialog = new ContentDialog();
            dialog.Title = diag.Title;
            dialog.Content = diag.Content;
            dialog.IsPrimaryButtonEnabled = diag.PrimBtnEnable;
            dialog.IsSecondaryButtonEnabled = diag.SecBtnEnable;
            if (diag.PrimBtnEnable) dialog.PrimaryButtonText = diag.PrimBtnText;
            if (diag.SecBtnEnable) dialog.SecondaryButtonText = diag.SecBtnText;
            dialog.CloseButtonText = diag.CloseBtnText;
            switch (diag.DefaultBtn)
            {
                case 0:
                    dialog.DefaultButton = ContentDialogButton.Close;
                    break;
                case 1:
                    dialog.DefaultButton = ContentDialogButton.Primary;
                    break;
                case 2:
                    dialog.DefaultButton = ContentDialogButton.Secondary;
                    break;
            }
            result = await dialog.ShowAsync();
            return result;
        }
    }
}
