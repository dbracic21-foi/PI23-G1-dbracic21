using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaulationManager {
    public abstract class Person:object {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        public override string ToString() {
            return firstName + " " + lastName;
        }


    }
}
