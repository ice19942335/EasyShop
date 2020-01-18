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
            if(item.children.length === 5){
                this.SetEvent(item.children[2]);
            }
        }
    }
    SetEvent(item){
        item.addEventListener('click', (event) => {
            event.preventDefault();
            if(event.target.id == "markAsRead"){
                let id = event.target.dataset.notificationid;
                console.log(event);
                console.log(id);

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