
using System;
using System.IO;
using System.Linq;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;

namespace Chafimex.CodeGenerator
{
    public partial class Form1 : Form
    {
        private string implDaoCode;
        private string interfaceDaoCode;

        private string implServiceCode;
        private string interfaceServiceCode;

        private string formForm;
        private string formFormDes;
        private string formFormRes;
        private string formController;
        private string formSearchForm;
        private string formSearchFormDes;
        private string chooserControl;
        private string chooserControlDes;
        private string daoXMLTemplate;
        private string serviceXMLTemplate;

        private static string schemeName = "#Schema#";
        private static string entityName = "#EntityName#";

        private static string tDaoPath = ".." + Path.DirectorySeparatorChar + "TDao" + Path.DirectorySeparatorChar;
        private static string tServicePath = ".." + Path.DirectorySeparatorChar + "TService" + Path.DirectorySeparatorChar;
        private static string tFormsPath = ".." + Path.DirectorySeparatorChar + "TForms" + Path.DirectorySeparatorChar;
        private static string tXMLPath = ".." + Path.DirectorySeparatorChar + "TXML" + Path.DirectorySeparatorChar;
        private static string tControlsPath = ".." + Path.DirectorySeparatorChar + "TControls" + Path.DirectorySeparatorChar;

        private static string daoFolderPath = ".." + Path.DirectorySeparatorChar + "GenDao" + Path.DirectorySeparatorChar;
        private static string serviceFolderPath = ".." + Path.DirectorySeparatorChar + "GenService" + Path.DirectorySeparatorChar;
        private static string formFolderPath = ".." + Path.DirectorySeparatorChar + "GenForms" + Path.DirectorySeparatorChar;
        private static string xmlFolderPath = ".." + Path.DirectorySeparatorChar + "GenXML" + Path.DirectorySeparatorChar;
        private static string controlsFolderPath = ".." + Path.DirectorySeparatorChar + "GenControls" + Path.DirectorySeparatorChar;

        private static string implDaoFolderPath = daoFolderPath + "Impl" + Path.DirectorySeparatorChar;
        private static string interfaceDaoFolderPath = daoFolderPath + "Interfaces" + Path.DirectorySeparatorChar;
        private static string implServiceFolderPath = serviceFolderPath + "Impl" + Path.DirectorySeparatorChar;
        private static string interfaceServiceFolderPath = serviceFolderPath + "Interfaces" + Path.DirectorySeparatorChar;

        private static string controllerFormFolderPath = formFolderPath + "Controllers" + Path.DirectorySeparatorChar;
        private static string formsFormFolderPath = formFolderPath + "Forms" + Path.DirectorySeparatorChar;
        private static string templatesFormFolderPath = formFolderPath + "Templates" + Path.DirectorySeparatorChar;

        public Form1()
        {
            InitializeComponent();

            implDaoCode = File.ReadAllText(tDaoPath + "ImplDao.txt");
            interfaceDaoCode = File.ReadAllText(tDaoPath + "InterfaceDao.txt");

            implServiceCode = File.ReadAllText(tServicePath + "ImplService.txt");
            interfaceServiceCode = File.ReadAllText(tServicePath + "InterfaceService.txt");

            formForm = File.ReadAllText(tFormsPath + "Form.txt");
            formFormDes = File.ReadAllText(tFormsPath + "Form.Designer.txt");
            formFormRes = File.ReadAllText(tFormsPath + "Form.resx.txt");
            formController = File.ReadAllText(tFormsPath + "Controller.txt");
            formSearchForm = File.ReadAllText(tFormsPath + "SearchForm.txt");
            formSearchFormDes = File.ReadAllText(tFormsPath + "SearchForm.Designer.txt");
            chooserControl = File.ReadAllText(tControlsPath + "ChooserControl.txt");
            chooserControlDes = File.ReadAllText(tControlsPath + "ChooserControl.designer.txt");
            daoXMLTemplate = File.ReadAllText(tXMLPath + "Dao.txt");
            serviceXMLTemplate = File.ReadAllText(tXMLPath + "Service.txt");
        }

        private void ubtnGenerate_Click(object sender, EventArgs e)
        {
            string daoXML = string.Empty;
            string serviceXML = string.Empty;

            try
            {
                if (Directory.Exists(daoFolderPath))
                    Directory.Delete(daoFolderPath, true);
                if (Directory.Exists(serviceFolderPath))
                    Directory.Delete(serviceFolderPath, true);
                if (Directory.Exists(formFolderPath))
                    Directory.Delete(formFolderPath, true);

                Directory.CreateDirectory(daoFolderPath);
                Directory.CreateDirectory(serviceFolderPath);
                Directory.CreateDirectory(formFolderPath);
                Directory.CreateDirectory(xmlFolderPath);
                Directory.CreateDirectory(controlsFolderPath);

                Directory.CreateDirectory(implDaoFolderPath);
                Directory.CreateDirectory(interfaceDaoFolderPath);
                Directory.CreateDirectory(implServiceFolderPath);
                Directory.CreateDirectory(interfaceServiceFolderPath);

                Directory.CreateDirectory(controllerFormFolderPath);
                Directory.CreateDirectory(formsFormFolderPath);
                Directory.CreateDirectory(templatesFormFolderPath);

                IList<string> lst = File.ReadAllLines(this.txtFile.Text).ToList();
                string schema = lst.First();
                lst.RemoveAt(0);
                string[] lines = lst.ToArray();

                foreach (string l in lines)
                {
                    string line = l.Trim();

                    string imdc = implDaoCode.Replace(entityName, line);
                    string indc = interfaceDaoCode.Replace(entityName, line);
                    string imsc = implServiceCode.Replace(entityName, line);
                    string insc = interfaceServiceCode.Replace(entityName, line);
                    string ff = formForm.Replace(entityName, line);
                    string ffd = formFormDes.Replace(entityName, line);
                    string ffr = formFormRes.Replace(entityName, line);
                    string fc = formController.Replace(entityName, line);
                    string fsf = formSearchForm.Replace(entityName, line);
                    string fsfd = formSearchFormDes.Replace(entityName, line);
                    string cc = chooserControl.Replace(entityName, line);
                    string ccd = chooserControlDes.Replace(entityName, line);
                    string subDaoXML = daoXMLTemplate.Replace(entityName, line);
                    string subServiceXML = serviceXMLTemplate.Replace(entityName, line);

                    imdc = imdc.Replace(schemeName, schema);
                    indc = indc.Replace(schemeName, schema);
                    imsc = imsc.Replace(schemeName, schema);
                    insc = insc.Replace(schemeName, schema);
                    ff = ff.Replace(schemeName, schema);
                    ffd = ffd.Replace(schemeName, schema);
                    ffr = ffr.Replace(schemeName, schema);
                    fc = fc.Replace(schemeName, schema);
                    fsf = fsf.Replace(schemeName, schema);
                    fsfd = fsfd.Replace(schemeName, schema);
                    cc = cc.Replace(schemeName, schema);
                    ccd = ccd.Replace(schemeName, schema);
                    daoXML += subDaoXML.Replace(schemeName, schema);
                    serviceXML += subServiceXML.Replace(schemeName, schema);

                    File.WriteAllText(implDaoFolderPath + line + "Dao.cs", imdc, Encoding.UTF8);
                    File.WriteAllText(interfaceDaoFolderPath + "I" + line + "Dao.cs", indc, Encoding.UTF8);

                    File.WriteAllText(implServiceFolderPath + line + "Service.cs", imsc, Encoding.UTF8);
                    File.WriteAllText(interfaceServiceFolderPath + "I" + line + "Service.cs", insc, Encoding.UTF8);

                    File.WriteAllText(formsFormFolderPath + line + "Form.cs", ff, Encoding.UTF8);
                    File.WriteAllText(formsFormFolderPath + line + "Form.designer.cs", ffd, Encoding.UTF8);
                    File.WriteAllText(formsFormFolderPath + line + "Form.resx", ffr, Encoding.UTF8);
                    File.WriteAllText(controllerFormFolderPath + line + "FormController.cs", fc, Encoding.UTF8);
                    File.WriteAllText(templatesFormFolderPath + line + "SearchForm.cs", fsf, Encoding.UTF8);
                    File.WriteAllText(templatesFormFolderPath + line + "SearchForm.Designer.cs", fsfd, Encoding.UTF8);
                    File.WriteAllText(controlsFolderPath + line + "ChooserControl.cs", cc, Encoding.UTF8);
                    File.WriteAllText(controlsFolderPath + line + "ChooserControl.designer.cs", ccd, Encoding.UTF8);
                }

                File.WriteAllText(xmlFolderPath + "Dao.xml", daoXML, Encoding.UTF8);
                File.WriteAllText(xmlFolderPath + "Service.xml", serviceXML, Encoding.UTF8);
            }
            catch
            {
            }
        }

        private void btnDetSearchFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.txtFile.Text = dialog.FileName;
            }
        }
    }
}
