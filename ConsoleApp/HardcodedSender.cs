using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiffLib;
using DiffLib.Packets;

namespace ConsoleApp
{
    public class HardcodedSender : DiffLib.ISender
    {
        
        async Task<T> ISender.PostAsync<T, K>(string path, K obj)
        {
            Console.WriteLine($"HardcodedSender=> Path:{path}");
            T t = default(T);
            //t = await Task.Run<T>(() => { return default(T); });
            if (path == "/v1/diff/create")
            {
                t = await Task.Run<T>(() =>
                {
                    CreateIdCentralRequest objn = obj as CreateIdCentralRequest;
                    if (objn == null)
                        throw new ApplicationException("Incorrect request object for /v1/diff/create");

                    string newId = objn.WorkerId + "NEWID";
                    return new CreateIdResponse() { Id = newId } as T;
                });
            }

            else if (path.StartsWith("/v1/diff/"))
            {
                t = await Task.Run<T>(() =>
                {
                    CompleteIdCentralRequest objn = obj as CompleteIdCentralRequest;
                    if (objn == null)
                        throw new ApplicationException("Incorrect request object for /v1/diff/{ID}");

                    string id = path.Substring(9);
                    if (id != "w1" + "NEWID")
                        throw new ApplicationException("Unkown id. ID: " + id);
                    return new CompleteIdResponse() { Id = id } as T;
                });
            }

            else if (path.StartsWith("/v1/get-diff/"))
            {
                t = await Task.Run<T>(() =>
                {
                    GetDiffRequest objn = obj as GetDiffRequest;
                    if (objn == null)
                        throw new ApplicationException("Incorrect request object for /v1/get-diff/");

                    string id = path.Substring(13);
                    if (id != "w1" + "NEWID")
                        throw new ApplicationException("Unkown id. ID: " + id);
                    
                    return new GetDiffResponse() { Id = id, Result = "OK" } as T;
                });
            }

            return t;
        }
    }
}
