import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Task } from '../models/task';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  baseURL: string = 'http://localhost:5150/api/Task';

  constructor(private http: HttpClient) { }

  getAllTasks(): Observable<Task[]> {
    return this.http.get<Task[]>(this.baseURL);
  }

  createTask(newTask: Task): Observable<Task> {
    return this.http.post<Task>(this.baseURL, newTask);
  }

  updateTask(updatedTask: Task): Observable<Task> {
    return this.http.put<Task>(`${this.baseURL}/${updatedTask.taskId}`, updatedTask);
  }

  deleteTask(taskId: number): Observable<Task> {
    return this.http.delete<Task>(`${this.baseURL}/${taskId}`);
  }

}
