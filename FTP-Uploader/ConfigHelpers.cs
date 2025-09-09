using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static FTP_Uploader.SettingsAdapter;

namespace FTP_Uploader
{
    public static class ConfigHelpers
    {
        public static StorageConfig? TryBuildConfigFromUi(ComboBox cboProtocolo,
                                                          TextBox txtHost,
                                                          TextBox txtPorta,
                                                          TextBox txtUsuario,
                                                          TextBox txtSenha,
                                                          TextBox txtPastaRemota,
                                                          TextBox txtBaseUrlPublica,
                                                          CheckBox chkModoPassivo,
                                                          NumericUpDown numTimeoutMs,
                                                          out List<(Control ctl, string msg)> errors)
        {
            errors = new List<(Control, string)>();
        }
    }
}
