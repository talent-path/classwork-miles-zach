using System;
using System.Collections.Generic;
using System.Linq;

namespace WidgetCrud
{
    public class InMemWidgetDao
    {
        List<Widget> _allWidgets = new List<Widget>();

        public InMemWidgetDao()
        {
        }


        public int AddWidget(Widget toAdd)
        {
            if (_allWidgets.Count == 0)
            {
                toAdd.Id = 1;
            }
            else
            {
                Widget lastInserted = _allWidgets.TakeLast(1).Single();
                toAdd.Id = lastInserted.Id + 1;
            }
            _allWidgets.Add(toAdd);
            return toAdd.Id;
        }

        public void RemoveWidgetById(int id)
        {
            Widget widget = _allWidgets.FirstOrDefault(widget => widget.Id == id);
            _allWidgets.Remove(widget);
        }

        public void UpdateWidget(Widget updated)
        {
            int index = _allWidgets.FindIndex(widget => widget.Id == updated.Id);
            _allWidgets[index] = updated;
        }

        public Widget GetWidgetById(int id)
        {
            return _allWidgets.FirstOrDefault(widget => widget.Id == id);
        }

        public IEnumerable<Widget> GetWidgetsByCategory(string category)
        {
            return _allWidgets.Where(w => w.Category == category);
        }

        public IEnumerable<Widget> GetAllWidgetsForPage(int pageSize, int pageNumber)
        {
            //assuming each page is pageSize wide, return the pageNumberth page of widgets
            //order by name?

            //pageSize = 3 and pageNumber = 5 then skip first 12 1st: 1-3 2nd: 4-6 3rd: 7-9 4th: 10-12
            // skip pageSize * (pageNumber - 1)

            return _allWidgets
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .OrderBy(w => w.Name);
        }
    }
}
