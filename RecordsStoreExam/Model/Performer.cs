using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RecordsStoreExam.Model
{
    internal class Performer
    {
        public Label Label { get; set; }
        public bool IsSelected { get; set; }

        public Performer(Label label, bool isSelected)
        {
            Label = label; 
            IsSelected = isSelected;
        }
    }
}
