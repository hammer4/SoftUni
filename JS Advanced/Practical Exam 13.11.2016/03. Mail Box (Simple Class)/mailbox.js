class MailBox{
    constructor(){
        this.messages = [];
    }

    addMessage(subject, text){
        this.messages.push({
            subject: subject,
            text: text
        });

        return this;
    }

    get messageCount(){
        return this.messages.length;
    }

    deleteAllMessages(){
        this.messages = [];
    }

    findBySubject(substr){
        let output = [];

        this.messages.filter(m => m.subject.includes(substr)).forEach(m => output.push(m));

        return output;
    }

    toString(){
        if(! this.messages.length){
            return " * (empty mailbox)";
        } else {
            let output = "";

            this.messages.forEach(m => output += ` * [${m.subject}] ${m.text}\n`);

            return output.substring(0, output.length-1);
        }
    }
}

