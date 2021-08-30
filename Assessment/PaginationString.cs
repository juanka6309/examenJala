using System.Collections.Generic;
using System.Linq;
using System;


namespace Assessment
{
    public class PaginationString : IPagination<string>
    {
        private readonly IEnumerable<string> data;
        private readonly int pageSize;
        private int currentPage;

        public  PaginationString(string source, int pageSize, IElementsProvider<string> provider,string typeSeparator)
        {
            data = provider.ProcessData(source, typeSeparator);
            currentPage = 1;
            this.pageSize = pageSize;
        }
        public void FirstPage()
        {
            currentPage = 1;
        }

        public void GoToPage(int page)
        {
            if( currentPage>=1  && currentPage <= data.Count())
            {
                currentPage = page;
            }
            else
            {
                throw new InvalidOperationException("the page does not exist"); 
            }
        }

        public void LastPage()
        {
            currentPage = data.Count();
        }

        public void NextPage()
        {
            if(currentPage< data.Count())
            {
                currentPage++;
            }
            else
            {
                throw new InvalidOperationException("there is no next page");
            }
        }

        public void PrevPage()
        {
            if (currentPage > 1)
            {
                currentPage--;
            }
            else
            {
                throw new InvalidOperationException("there is no previous page");
            }
        }

        public IEnumerable<string> GetVisibleItems()
        {
            return data.Skip(this.currentPage*this.pageSize).Take(5);
        }

        public int CurrentPage()
        {
            print("number of pages", data.Count().ToString());
            return currentPage;
        }

        public int Pages()
        {
           print("page quantity", data.Count().ToString());
          return  data.Count();
        }

        public void print(string text, string value)
        {
            Console.WriteLine(text + ": " + value);
        }
    }
}