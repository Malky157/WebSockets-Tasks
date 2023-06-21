import React, { useState, useEffect, useRef } from "react";
import axios from "axios";
import { HubConnectionBuilder } from "@microsoft/signalr";
import { useAuth } from "./AuthContext";

const Home = () => {

    const { user } = useAuth();
    const connRef = useRef(null)
    const [taskTitle, setTaskTitle] = useState('');
    const [tasks, setTasks] = useState([]);

    useEffect(() => {
        const runFuncs = () => {
            getTasks();
            connectToHub();
        }
        runFuncs();
    }, [])

    const getTasks = async () => {
        const { data } = await axios.get('api/taskitem/gettaskitems')
        setTasks(data)
    }

    const onAddClick = async () => {

        setTaskTitle('')
        await axios.post('api/taskitem/addtaskitem', { title: taskTitle })
    }

    const onStatusButtonClick = async (task, status) => {
        await axios.post('api/taskitem/updatestatus', { item: task, status })
    }

    const whatsStatus = (task) => {
        const result = { taskId: task.id, buttonClass: null, buttonText: null, status: "" }

        if (task.userIdStarted === 0) {

            result.buttonClass = ' btn-dark'
            result.buttonText = "I'm doing this one!"
            result.status = "not taken"

        } else {
            if (task.userIdStarted === user.id) {
                result.buttonClass = ' btn-success'
                result.buttonText = "I'm done!"
                result.status = "in progress by me"
            } else {

                result.buttonClass = ' btn-warning'
                result.buttonText = `${user.name} is doing this one`
                result.status = "in progress by someone else"
            }
        }
        return <button
            disabled={result.status === "in progress by someone else"}
            className={`btn ${result.buttonClass}`}

            onClick={() => onStatusButtonClick(task, result.status)}>
            {result.buttonText}
        </button>
    }

    const connectToHub = async () => {

        const connection = new HubConnectionBuilder().withUrl("/api/taskitem").build();
        await connection.start();
        connRef.current = connection;

        connection.on('newTask', taskItems => {
            setTasks(taskItems);
        })

        connection.on('updatedTask', taskItems => {
            setTasks(taskItems)
        })
    }

    return <>
        <div className="container" style={{ marginTop: 90 }}>
            <div className="row">
                <div className="col-md-8">
                    <input
                        type="text"
                        className="form-control"
                        placeholder="Task Title"
                        value={taskTitle}
                        onChange={(e) => setTaskTitle(e.target.value)}
                    />
                </div>
                <div className="col-md-2">
                    <button className="btn btn-primary w-100" onClick={onAddClick}>Add Task</button>
                </div>
            </div>
            <div className="col-md-10">
                <table className="table table-hover mt-3">
                    <thead>
                        <tr>
                            <th>Title</th>
                            <th>Status</th>
                        </tr>
                    </thead>
                    <tbody>
                        {tasks.map(t =>
                            <tr key={t.id}>

                                <td>{t.title}</td>
                                <td>
                                    {whatsStatus(t)}
                                </td>
                            </tr>)}
                    </tbody>
                </table>
            </div>
        </div>
    </>
}

export default Home;