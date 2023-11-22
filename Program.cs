// See https://aka.ms/new-console-template for more information

using Storing_and_Updating_Teacher_Records.Models;

public class Program
{


    public static void Main(string[] args)
    {
        string filePath = "C:\\Users\\22575\\source\\repos\\Storing and Updating Teacher Records\\Storing and Updating Teacher Records\\files\\Teacher_Records.txt";
        TeacherRecordManager recordManager = new TeacherRecordManager(filePath);

        List<TeacherModels> teachers = recordManager.ReadTeacherRecords();
        bool isValid = false;
        while (!isValid)
        {
            Console.WriteLine("Choose the Option");
            Console.WriteLine("1. Update the teacher Records");
            Console.WriteLine("2. Store the teacher Records");
            Console.WriteLine("-----------------------------");
            string options = Console.ReadLine();



            switch (options?.ToLower())
            {
                case "update" or "1":
                    UpdateTeacherRecord(teachers, recordManager);
                 
                    isValid = true; 
                    break;
                case "store" or "2":
                    int data = StoreTeacherRecord(teachers, recordManager);
                    StoreTeacherRecord(teachers, recordManager);
                    isValid=true;   
                    break;
                default:
                    Console.WriteLine("You have entered wrong option");
                    break;
            }

        }

    }
    static void UpdateTeacherRecord(List<TeacherModels> teachers, TeacherRecordManager recordManager)
    {
        Console.WriteLine("Enter teacher ID to update:");
        int id = int.Parse(Console.ReadLine());

        TeacherModels teacherToUpdate = teachers.Find(t => t.Id == id);
        if (teacherToUpdate != null)
        {
            Console.WriteLine("Enter updated Name:");
            string name = Console.ReadLine();
            Console.WriteLine("---------------------");
            Console.WriteLine("Enter updated Subject:");
            string subject = Console.ReadLine();
            Console.WriteLine("---------------------");
            Console.WriteLine("Enter updated Class:");
            string Class = Console.ReadLine();
            Console.WriteLine("---------------------");
            Console.WriteLine("Enter updated Section:");
            string Section = Console.ReadLine();

            teacherToUpdate.Name = name;
            teacherToUpdate.Subject = subject;
            teacherToUpdate.Section = Section;
            teacherToUpdate.Class = Class;

            recordManager.WriteTeacherRecords(teachers);
            Console.WriteLine("Teacher record updated successfully.");          

        }
        else
        {
            Console.WriteLine("Teacher ID not found.");
        }
    }

    static int StoreTeacherRecord(List<TeacherModels> teachers, TeacherRecordManager recordManager)
    {
        Console.WriteLine("Enter teacher information (ID, Name, Subject):");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("Enter id :");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("---------------------");
        Console.WriteLine("Enter Name :");
        string name = Console.ReadLine();
        Console.WriteLine("---------------------");
        Console.WriteLine("Enter Subject :");
        string subject = Console.ReadLine();
        Console.WriteLine("---------------------");
        Console.WriteLine("Enter Class");
        string Class = Console.ReadLine();
        Console.WriteLine("---------------------");
        Console.WriteLine("Enter Section");
        string Section = Console.ReadLine();

        if (teachers.Exists(t => t.Id == id))
        {
            Console.WriteLine("Teacher with the same ID already exists.");
            return 1;
        }
        else
        {
            teachers.Add(new TeacherModels(id, name, subject, Class, Section));
            recordManager.WriteTeacherRecords(teachers);
            Console.WriteLine("Teacher record added successfully.");
            return 0;
        }
    }


}




