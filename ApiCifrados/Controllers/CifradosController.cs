using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ApiCifrados.Input;
using Cifrados;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCifrados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CifradosController : ControllerBase
    {
        public static IWebHostEnvironment _environment;
        public CifradosController(IWebHostEnvironment env)
        {
            _environment = env;
        }

       

        //-------- Metodos Cifrados --------------------
        Cesar CifradoCesar = new Cesar();
        Zigzag CifradoZigZag = new Zigzag();
        //Ruta CifradoRuta = new Ruta();

        public void CifrarArchivos(IFormFile objFile,string method, Key Key)
        {
            string[] FileName1 = objFile.FileName.Split(".");
            switch (method)
            {
                case "Cesar":
                    {
                        CifradoCesar.Cifrar(_environment.ContentRootPath + "\\ArchivosCifrados\\" + objFile.FileName, _environment.ContentRootPath + "\\ArchivosCifrados\\" + FileName1[0] + ".csr",Key.Word);
                    }   
                    break;
                case "ZigZag":
                    {
                        CifradoZigZag.Cifrar(_environment.ContentRootPath + "\\ArchivosCifrados\\" + objFile.FileName, _environment.ContentRootPath + "\\ArchivosCifrados\\" + FileName1[0] + ".zz",Key.Level);
                    }
                    break;
                case "Ruta":
                    {
                        //CifradoRuta.Cifrar(_environment.ContentRootPath + "\\ArchivosCifrados\\" + objFile.FileName, _environment.ContentRootPath + "\\ArchivosCifrados\\" + FileName1[0] + ".rt",);

                    }
                    break;
            }


        }

        public void DescifrarArchivos(IFormFile objFile,string method, Key Key)
        {
            string[] FileName1 = objFile.FileName.Split(".");

            switch (method)
            {
                case ".csr":
                    {
                        CifradoCesar.Cifrar(_environment.ContentRootPath + "\\ArchivosCifrados\\" + objFile.FileName, _environment.ContentRootPath + "\\ArchivosCifrados\\" + FileName1[0] + ".csr", Key.Word);
                    }
                    break;
                case ".zz":
                    {
                        CifradoZigZag.Cifrar(_environment.ContentRootPath + "\\ArchivosCifrados\\" + objFile.FileName, _environment.ContentRootPath + "\\ArchivosCifrados\\" + FileName1[0] + ".zz", Key.Level);
                    }
                    break;
                case ".rt":
                    {
                        //CifradoRuta.Cifrar(_environment.ContentRootPath + "\\ArchivosCifrados\\" + objFile.FileName, _environment.ContentRootPath + "\\ArchivosCifrados\\" + FileName1[0] + ".rt",);

                    }
                    break;
            }

        }






        [Route("/api/cipher/{method}")]
        [HttpPost]
        public async Task<IActionResult> SubirFileTxt(string method, Key Key,[FromForm] IFormFile objFile)
        {
            try
            {
                if (objFile.Length > 0)
                {
                    if (!Directory.Exists(_environment.ContentRootPath + "\\ArchivosCifrados\\")) Directory.CreateDirectory(_environment.ContentRootPath + "\\ArchivosCifrados\\");
                    using var _fileStream = System.IO.File.Create(_environment.ContentRootPath + "\\ArchivosCifrados\\" + objFile.FileName);
                    objFile.CopyTo(_fileStream);
                    _fileStream.Flush();
                    _fileStream.Close();

                    CifrarArchivos(objFile, method, Key);
                    var memory = new MemoryStream();

                    switch (method)
                    {
                        case "Cesar":
                            {
                                using (var stream = new FileStream(_environment.ContentRootPath + "\\ArchivosCifrados\\" + ".csr", FileMode.Open))
                                {
                                    await stream.CopyToAsync(memory);
                                }

                                memory.Position = 0;
                                return File(memory, System.Net.Mime.MediaTypeNames.Application.Octet,  ".csr");
                            }
                            //break;
                        case "ZigZag":
                            {
                                using (var stream = new FileStream(_environment.ContentRootPath + "\\ArchivosCifrados\\" + ".zz", FileMode.Open))
                                {
                                    await stream.CopyToAsync(memory);
                                }

                                memory.Position = 0;
                                return File(memory, System.Net.Mime.MediaTypeNames.Application.Octet,  ".zz");
                            }
                           // break;
                        case "Ruta":
                            {
                                using (var stream = new FileStream(_environment.ContentRootPath + "\\ArchivosCifrados\\" + ".rt", FileMode.Open))
                                {
                                    await stream.CopyToAsync(memory);
                                }

                                memory.Position = 0;
                                return File(memory, System.Net.Mime.MediaTypeNames.Application.Octet, ".rt");

                            }
                            //break;
                    }
                    
                }

                return StatusCode(404, "Archivo Vacio");

            }
            catch
            {

                return StatusCode(404, "Error");
            }
        }

        [Route("/api/decipher")]
        [HttpPost]
        public async Task<IActionResult> SubirFileHuff([FromForm] Key Key,[FromForm] IFormFile objFile)
        {
            try
            {
                if (objFile.Length > 0)
                {
                    string method = "." + objFile.FileName.Split(".")[1];

                    if (!Directory.Exists(_environment.ContentRootPath + "\\ArchivosCifrados\\")) Directory.CreateDirectory(_environment.ContentRootPath + "\\ArchivosCifrados\\");
                    using var _fileStream = System.IO.File.Create(_environment.ContentRootPath + "\\ArchivosCifrados\\" + objFile.FileName);
                    objFile.CopyTo(_fileStream);
                    _fileStream.Flush();
                    _fileStream.Close();
                    DescifrarArchivos(objFile,method, Key);

                    var memory = new MemoryStream();
                    var name = objFile.FileName;
                    using (var stream = new FileStream(_environment.ContentRootPath + "\\ArchivosCifrados\\" + objFile.FileName, FileMode.Open))
                    {
                        await stream.CopyToAsync(memory);
                    }

                    memory.Position = 0;
                    return File(memory, System.Net.Mime.MediaTypeNames.Application.Octet, objFile.FileName);
                }
                else
                {
                    return StatusCode(404, "Archivo Vacio");
                }
            }
            catch
            {
                return StatusCode(404, "Error");
            }
        }


    }
}
