internal class Program
{
    public static void AllPractice()
    {
        DriveInfo[] allDrives = DriveInfo.GetDrives();
        foreach (var drive in allDrives)
        {
            GetDriveInfo(drive);
        }
    }
    public static void GetDriveInfo(DriveInfo drive)
    {
        Console.WriteLine("\n--------------------------");

        Console.WriteLine($"Drive: {drive.Name}");
        if (drive.IsReady)
        {
            Console.WriteLine($"Volume Lable: {drive.VolumeLabel}");
            Console.WriteLine($"DriveType: {drive.DriveType}");
            Console.WriteLine($"DriveFormat: {drive.DriveFormat}");
            Console.WriteLine($"TotalSize:  {(drive.TotalSize/Math.Pow(1024, 3)).ToString("0.00")} GB");
            Console.WriteLine($"TotalFreeSpace: {(drive.TotalFreeSpace/ Math.Pow(1024, 3)).ToString("0.00")} GB");
            Console.WriteLine($"RootDirectory: {drive.RootDirectory}");
        }

        Console.WriteLine("--------------------------\n");
    }
    private static void Main(string[] args)
    {
        AllPractice();
    }
}