using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storing_and_Updating_Teacher_Records.Models
{
    public class TeacherModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Class { get; set; }
        public string Section { get; set; }
        public TeacherModels(int Id, string Name, string Subject, string Class, string Section)
        {
            this.Id = Id;
            this.Name = Name;
            this.Class = Class;
            this.Subject = Subject;
            this.Section = Section;
        }
        public override string ToString()
        {
            return $"{Id},{Name},{Class},{Section},{Subject}";
        }

    }

}
