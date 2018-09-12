using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPEntities.DataContext;
using ERPEntities.Models;
using System.Collections;
using System.Data.Linq;

namespace DataAccessLayer
{
    public class SchdeuleDAL
    {
        
        public IList getEvents()
        {
            ERPDataContext dc = new ERPDataContext();

            var Event = dc.Schedules.ToList();
            return Event;
        }

        public bool saveEvent(Schedule s)
        {
            var status = false;
            using (ERPDataContext dc = new ERPDataContext())
            {
                if (s.EventID > 0)
                {
                    //Update the event
                    var v = dc.Schedules.Where(a => a.EventID == s.EventID).FirstOrDefault();
                    if (v != null)
                    {
                        v.Subject = s.Subject;
                        v.Start = s.Start;
                        v.End = s.End;
                        v.Description = s.Description;
                        v.IsFullDay = s.IsFullDay;
                        v.Theme = s.Theme;
                    }
                }
                else
                {
                    dc.Schedules.InsertOnSubmit(s);
                }
                dc.SubmitChanges();
                status = true;
            }
            return status;
        }

        public bool deleteEvent(int eventID)
        {
            var status = false;
            using (ERPDataContext dc = new ERPDataContext())
            {
                var v = dc.Schedules.Where(a => a.EventID == eventID).FirstOrDefault();
                if (v != null)
                {
                    dc.Schedules.DeleteOnSubmit(v);
                    dc.SubmitChanges();
                    status = true;
                }            }
            return status;
        }
        
    }
}
