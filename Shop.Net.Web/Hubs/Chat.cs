namespace Shop.Net.Web.Hubs
{
    using Microsoft.AspNet.SignalR;

    public class Chat : Hub
    {
        public void SendMessage(string message)
        {
            var msg = string.Format("{0}: {1}", this.Context.ConnectionId, message);
            this.Clients.All.addMessage(msg);
        }

        public void JoinRoom(string room)
        {
            this.Groups.Add(this.Context.ConnectionId, room);
            this.Clients.Caller.joinRoom(room);
        }

        public void SendMessageToRoom(string message, string[] rooms)
        {
            var msg = string.Format("{0}: {1}", this.Context.ConnectionId, message);

            foreach (var t in rooms)
            {
                this.Clients.Group(t).addMessage(msg);
            }
        }
    }
}