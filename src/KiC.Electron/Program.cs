// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

var psiNpmRunDist = new ProcessStartInfo
{
    FileName = "cmd",
    RedirectStandardInput = true,
    WorkingDirectory = @"D:\KingsInTheCorners\src\KiC.Electron"
};
var pNpmRunDist = Process.Start(psiNpmRunDist);
pNpmRunDist.StandardInput.WriteLine("npm run start");
pNpmRunDist.WaitForExit();
