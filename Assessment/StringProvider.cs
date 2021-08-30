using System.Collections.Generic;
using System;


namespace Assessment
{
    public class StringProvider : IElementsProvider<string>
    {
        private readonly string separator = ",";
        private readonly string separatorPipe = "|";
        private readonly string separatorSpace = " ";


        public IEnumerable<string> ProcessData(string source,string typeString) {
            switch (typeString)
            {
                case "1":
                    return source.Split(this.separator);
                break;
                case "2":
                    return source.Split(this.separatorPipe);
                    break;
                case "3":
                    return source.Split(this.separatorSpace);
                break;
                default:
                    return source.Split(this.separator);
               break;
            }
        }
    }
}