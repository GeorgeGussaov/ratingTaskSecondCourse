using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ratingTask2
{
    public enum WeekDays 
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday, 
        Sunday
    }

    public class Lesson
    {
        public string Label { get; set; }
        public int Number { get; set; }
        public string WeekNumber { get; set; }
        public WeekDays Day { get; set; }
        public string GroupNumber { get; set; }
        public static char StaticLabelEmpty = (char)('A' - 1);
        public Lesson()
        {
            StaticLabelEmpty++;
            Label = StaticLabelEmpty.ToString();
        }
        public Lesson(string label, int number, int weekNumber, WeekDays day, string groupNumber)
        {
            Label = label;
            Number = number;
            if (weekNumber == 0) WeekNumber = "каждую неделю";
            else if (weekNumber == 1) WeekNumber = "по первой неделе";
            else if (weekNumber == 2) WeekNumber = "по второй неделе";
            Day = day;
            GroupNumber = groupNumber;
        }
        public override string ToString()
        {
            return $"{Label}, {Number} пара, {WeekNumber}, {Day}, {GroupNumber}";
        }
    }


    public class Schedule : IEnumerable<Lesson>, IEnumerator<Lesson>
    {
        public string Name { get; set; }
        public List<Lesson> listLesson = new List<Lesson>();
        private int currentIndex = -1;
        public Schedule(string name)
        {
            Name = name;
        }
        public void Add(Lesson les)
        {
            listLesson.Add(les);
        }
        public override string ToString()
        {
            return string.Join("\n", listLesson);
        }

        IEnumerator<Lesson> IEnumerable<Lesson>.GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        public Schedule(List<Lesson> users)
        {
            this.listLesson = users;
        }

        public Lesson Current => listLesson[currentIndex];

        object IEnumerator.Current => listLesson[currentIndex];

        public bool MoveNext()
        {
            currentIndex++;
            if (currentIndex >= listLesson.Count)
            {
                return false;
            }

            return true;
        }

        public void Reset()
        {
            currentIndex = -1;
        }

        public void Dispose()
        { }

    }


}
