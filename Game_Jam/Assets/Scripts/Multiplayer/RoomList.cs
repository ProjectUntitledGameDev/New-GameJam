using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomList : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private RoomListItem roomListItem;
    [SerializeField]
    private Transform content;
    private List<RoomListItem> listing = new List<RoomListItem>();
    public override void OnRoomListUpdate(List<Photon.Realtime.RoomInfo> roomList)
    {
        foreach(RoomInfo info in roomList)
        {
            if (info.RemovedFromList)
            {
                int index = listing.FindIndex(x => x.RoomInfo.Name == info.Name);
                if(index != -1)
                {
                    Destroy(listing[index].gameObject);
                    listing.RemoveAt(index);
                }
            }
            else
            {
                RoomListItem item = Instantiate(roomListItem, content);
                if (item != null)
                {
                    item.SetInfo(info);
                    listing.Add(item);
                }
                    

            }
            
        }
    }

}
