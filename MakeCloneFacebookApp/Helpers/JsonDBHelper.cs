using MakeCloneFacebookApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeCloneFacebookApp.Helpers
{
    public class JsonDBHelper : DBHelper
    {
        private const string PathFileName = "./data.dat";

        public Data Data { private set; get; }
        public bool IsOpenSuccess { private set; get; }
        public JsonDBHelper(bool IsAutoOpen = true)
        {
            Type = DBType.Json;
            Data = new Data();
            IsOpenSuccess = false;
            if (IsAutoOpen)
            {
                ReadData();
            }
        }
        public override bool Save()
        {
            try
            {
                string DataSave = JsonConvert.SerializeObject(Data).StringEndcoder();
                File.WriteAllText(PathFileName, DataSave);
                return true;
            }
            catch (Exception ex)
            {
                ex.StackTrace.WriteLog();
                return false;
            }
        }
        public override bool ReadData()
        {
            if (!IsOpenSuccess)
            {
                if (File.Exists(PathFileName))
                {
                    try
                    {
                        string DataString = File.ReadAllText(PathFileName).StringDecoder();
                        Data = JsonConvert.DeserializeObject<Data>(DataString);
                        IsOpenSuccess = true;
                        return true;
                    }
                    catch (Exception ex)
                    {
                        File.Delete(PathFileName);
                        ex.StackTrace.WriteLog();
                    }
                }
                else
                {
                    try
                    {
                        string DataSave = JsonConvert.SerializeObject(Data).StringEndcoder();
                        File.WriteAllText(PathFileName, DataSave);
                        IsOpenSuccess = true;
                        return true;
                    }
                    catch (Exception ex)
                    {
                        ex.StackTrace.WriteLog();
                    }
                }
                return false;
            }
            return true;
        }
        public IEnumerable<User> GetUsers()
        {
            return Data.Users;
        }
        public bool UserAction(User User, ActionType type = ActionType.Add)
        {
            if (IsOpenSuccess)
            {
                try
                {
                    var user = Data.Users.Where(u => u.UserName.Equals(User.UserName)).FirstOrDefault();
                    switch (type)
                    {
                        case ActionType.Add:
                            if (user == null)
                            {
                                Data.Users.Add(User);
                                Save();
                                return true;
                            }
                            return false;
                        case ActionType.Edit:
                            if (user != null)
                            {
                                Data.Users.Remove(user);
                                Data.Users.Add(User);
                                Save();
                                return true;
                            }
                            return false;
                        case ActionType.Remove:
                            if (user != null)
                            {
                                Data.Users.Remove(user);
                                Save();
                            }
                            return true;
                        default:
                            return false;
                    }
                }
                catch(Exception ex)
                {
                    ex.StackTrace.WriteLog();
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool SaveUsers(List<User> users)
        {
            if(IsOpenSuccess)
            {
                try
                {
                    Data.Users.RemoveAll(u => true);
                    Data.Users.AddRange(users);
                    Save();
                    return true;
                }
                catch(Exception ex)
                {
                    ex.Message.WriteLog();
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<SendMessage> GetSendMessages()
        {
            return Data.SendMessageTemplate;
        }
        public bool SenMessageAction(SendMessage sendMessage, ActionType type = ActionType.Add)
        {
            if (IsOpenSuccess)
            {
                try
                {
                    var message = Data.SendMessageTemplate.Where(m => m.Id == sendMessage.Id).FirstOrDefault();
                    switch (type)
                    {
                        case ActionType.Add:
                            if (message == null)
                            {
                                Data.SendMessageTemplate.Add(message);
                                Save();
                                return true;
                            }
                            return false;
                        case ActionType.Edit:
                            if (message != null)
                            {
                                Data.SendMessageTemplate.Remove(message);
                                Data.SendMessageTemplate.Add(sendMessage);
                                Save();
                                return true;
                            }
                            return false;
                        case ActionType.Remove:
                            if (message != null)
                            {
                                Data.SendMessageTemplate.Remove(message);
                                Save();
                            }
                            return true;
                        default:
                            return false;
                    }
                }
                catch (Exception ex)
                {
                    ex.StackTrace.WriteLog();
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool SaveSendMessages(List<SendMessage> sendMessages)
        {
            if (IsOpenSuccess)
            {
                try
                {
                    Data.SendMessageTemplate.RemoveAll(u => true);
                    Data.SendMessageTemplate.AddRange(sendMessages);
                    Save();
                    return true;
                }
                catch (Exception ex)
                {
                    ex.Message.WriteLog();
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<PostWallMessage> GetPostWallMessages()
        {
            return Data.PostWallContentsTemplate;
        }
        public bool PostWallMessageAction(PostWallMessage postWallMessage, ActionType type = ActionType.Add)
        {
            if (IsOpenSuccess)
            {
                try
                {
                    var message = Data.PostWallContentsTemplate.Where(m => m.Id == postWallMessage.Id).FirstOrDefault();
                    switch (type)
                    {
                        case ActionType.Add:
                            if (message == null)
                            {
                                Data.PostWallContentsTemplate.Add(message);
                                Save();
                                return true;
                            }
                            return false;
                        case ActionType.Edit:
                            if (message != null)
                            {
                                Data.PostWallContentsTemplate.Remove(message);
                                Data.PostWallContentsTemplate.Add(postWallMessage);
                                Save();
                                return true;
                            }
                            return false;
                        case ActionType.Remove:
                            if (message != null)
                            {
                                Data.PostWallContentsTemplate.Remove(message);
                                Save();
                            }
                            return true;
                        default:
                            return false;
                    }
                }
                catch (Exception ex)
                {
                    ex.StackTrace.WriteLog();
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool SavePostWallMessages(List<PostWallMessage> postWallMessages)
        {
            if (IsOpenSuccess)
            {
                try
                {
                    Data.PostWallContentsTemplate.RemoveAll(u => true);
                    Data.PostWallContentsTemplate.AddRange(postWallMessages);
                    Save();
                    return true;
                }
                catch (Exception ex)
                {
                    ex.Message.WriteLog();
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
