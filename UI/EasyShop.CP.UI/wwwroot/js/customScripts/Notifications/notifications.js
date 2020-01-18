'use strict';

const API = document.getElementById('url').value;

class Notifications {
    constructor(){
        this.Initialize();
    }
    Initialize(){
        this.AddEventHandlersOnMarkAsRead()
    }
    AddEventHandlersOnMarkAsRead(){
        let notList = this.GetListOfNotifications();

        for (const item of notList.children) {
            console.log(item);
            console.log(item.children.length);
            if (item.children.length === 6) {
                this.SetEvent(item.children[3]);
            } else if (item.children.length === 9){
                this.SetEvent(item.children[3]);
            }
        }
    }
    SetEvent(item){
        item.addEventListener('click', (event) => {
            event.preventDefault();
            if(event.target.id === "markAsRead"){
                let id = event.target.dataset.notificationid;
                this.fetchData(`${API}?notificationId=${id}`)
                event.target.style.display = "none";
                event.target.parentNode.classList.add('disabled')
            }
        });
    }
    fetchData(url) {
        return fetch(url)
            .then(result => result.json())
            .catch(error => console.log(error));
    }
    GetListOfNotifications(){
        return document.getElementById('notificationsList');
    }
}

const notifications = new Notifications(); //Self Initialization