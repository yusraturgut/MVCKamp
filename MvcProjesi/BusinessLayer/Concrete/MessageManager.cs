using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager:IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetByID(int id)
        {
            return _messageDal.Get(x => x.MessageID == id);
        }

        public List<Message> GetListInbox(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p);
        }
        public List<Message> GetListSendbox(string p)
        {
            return _messageDal.List(x => x.SenderMail == p);
        }


        public void MessageAdd(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            _messageDal.Delete(message);
        }
        public List<Message> GetAllRead()
        {
            return _messageDal.List(m => m.ReceiverMail == "admin@gail.com").Where(x => x.ısRead==false).ToList();
        }

        public void MessageUpdate(Message message)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetListInbox()
        {
            throw new NotImplementedException();
        }

        
    }
}
