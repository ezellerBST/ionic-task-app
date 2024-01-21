import { Component, OnInit } from '@angular/core';
import { Task } from '../models/task';
import { TaskService } from '../services/task.service';
import { DialogService } from '../services/dialog.service';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage implements OnInit {

  taskList: Task[] = [];
  newTask: Task = new Task();


  constructor(
    private taskService: TaskService,
    private dialogService: DialogService,
  ) { }

  ngOnInit(): void {
    this.loadTasks();
  };

  loadTasks() {
    this.taskService.getAllTasks().subscribe(task => {
      this.taskList = task;
      console.log('Task list:', this.taskList);
    });
  }

  deleteTask(taskId: number | undefined): void {
    if (taskId)
      this.taskService.deleteTask(taskId).subscribe({
        next: () => {
          this.taskList = this.taskList.filter(task => task.taskId !== taskId);
        },
        error: (error: any) => {
          console.log('Error:', error);
        }
      });
  }

  openTaskPrompt() {
    this.dialogService.showPrompt('Create New Task', 'Task Title').subscribe(response => {
      if (response) {
        this.newTask.title = response;
        this.createTask();
      }
    });
  }

  createTask() {
    if (this.newTask.title) {
      this.taskService.createTask(this.newTask).subscribe(() => {
        this.loadTasks();
        this.newTask.title = '';
        console.log('Task created.');
      });
    }
  }

  updateTask() {
    this.taskService.updateTask(this.newTask).subscribe({
      next: (updatedTask: Task) => {
        this.newTask = updatedTask;
        this.loadTasks();
      },
      error: (error: any) => {
        console.log('Error:', error);
      }
    });
  }

  taskCompleted(task: Task) {
    task.completed = !task.completed;
    this.taskService.updateTask(task).subscribe(() => {
      this.loadTasks();

      if(task.completed) {
        this.taskList = this.taskList.filter((t) => !t.completed);
      } else {
        this.taskList = this.taskList.filter((t) => t.completed);
      }
    });
  }
}
