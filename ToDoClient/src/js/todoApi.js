export default class {
    constructor (baseurl){
        this.baseurl = baseurl;
    }

    async getTodos(){
        console.log("Hola");
        let raw = await fetch(this.baseurl + 'todoitems/',{
            
            cache:'no-cache',
            method:'GET',
            mode:'cors'
        });

        let pdata =await raw.json();
        console.log(pdata);
        return pdata;
    }

    async addTodo(todo){
        let req =await fetch(this.baseurl + 'todoitems/',{
            method:'POST',
            headers:{
                Accept: 'application/json','Content-Type':'application/json'
            },
            body: JSON.stringify(todo),
        });

        let res = await req.json();
        return res;
    }

    async deleteTodo(id) {
        let req =await fetch(this.baseurl + 'todoitems/' +id,{
            method:'DELETE'
    });
    let res = await req.json();
    return res;
}

    async setTodoComplete(todo, id){
        let req =await fetch(this.baseurl + 'todoitems/'+id,{
            method:'PATCH',
            headers:{
            'Content-Type':'application/json'
            },
            body: JSON.stringify(todo),
        });


        return;

    }
}