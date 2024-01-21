export class Task {
    taskId?: number;
    title?: string;
    completed?: boolean;

    constructor(id?: number, title?: string, completed?: boolean) {
        this.taskId = id;
        this.title = title;
        this.completed = completed;
    }
}
