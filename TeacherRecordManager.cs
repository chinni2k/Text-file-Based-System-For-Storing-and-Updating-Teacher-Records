using Storing_and_Updating_Teacher_Records.Models;
using System;
using System.Collections.Generic;
using System.IO;

public class TeacherRecordManager
{
    private string filePath;

    public TeacherRecordManager(string filePath)
    {
        this.filePath = filePath;
    }

    public List<TeacherModels> ReadTeacherRecords()
    {
        List<TeacherModels> teachers = new List<TeacherModels>();

        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 5)
                    {
                        int id = int.Parse(parts[0]);
                        string name = parts[1];
                        string subject = parts[2];
                        string Class= parts[3]; 
                        string Section = parts[4];
                        teachers.Add(new TeacherModels(id, name, subject,Class,Section));                 
                    }
                }
            }
        }

        return teachers;
    }

    public void WriteTeacherRecords(List<TeacherModels> teachers)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (TeacherModels teacher in teachers)
            {
                writer.WriteLine(teacher.ToString());
            }
        }
    }

    public void UpdateTeacherRecord(int id, string name, string subject,string Class, string Section, List<TeacherModels> teachers)
    {
        TeacherModels teacherToUpdate = teachers.Find(t => t.Id == id);
        if (teacherToUpdate != null)
        {
            teacherToUpdate.Name = name;
            teacherToUpdate.Subject = subject;
            teacherToUpdate.Class = Class;
            teacherToUpdate.Section = Section;  
            
        }
    }
}

