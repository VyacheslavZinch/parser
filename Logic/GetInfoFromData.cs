using Microsoft.VisualBasic;
using MSHTML;
using System.Text;

namespace LocalInfoFromResponse
{
    class ViewData
    {
        private readonly List<string> data;
        private StringBuilder result = new StringBuilder();

        public ViewData(List<string> dataForView)
        {
            this.data = dataForView;
        }
        public void formatData()
        {
            foreach (var item in data)
            {
                result.Append(item.ToString());
                result.Append('\n');
            }
            MessageBox.Show(result.ToString());
        }


    }
}