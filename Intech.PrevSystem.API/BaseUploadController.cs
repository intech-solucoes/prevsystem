#region Usings
using System.IO;
using System;
#endregion

namespace Intech.PrevSystem.API
{
    public class BaseUploadController : BaseController
    {
        public static string DiretorioUpload =>
            Path.Combine(Environment.CurrentDirectory, "Upload");
    }
}
