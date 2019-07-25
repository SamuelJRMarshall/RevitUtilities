using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLogic
{
    public class Memory
    {
        /// Answer list
        /// Clear
        /// Delete
        /// Previous Answer

        private float a, b;
        private string currentOperator;
        public bool calculate;
        
        public void SaveA(string incoming)
        {
            a = float.Parse(incoming);
        }

        public void SetOperator(string incoming)
        {
            currentOperator = incoming;
        }

    }
}
