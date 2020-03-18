using System;
using System.Collections.Generic;
using System.Text;

namespace BasicSelenium.Values
{
    class State
    {
        public static State CALIFORNIA = new State("California", 0);
        public static State FLORIDA = new State("Florida", 1);
        public static State OHIO = new State("Ohio", 4);

        public string state;
        public int index;

        public State(string state, int index)
        {
            this.state = state;
            this.index = index;
        }
    }
}
