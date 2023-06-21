import React, { useEffect } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import { useAuth } from "./AuthContext";

const Logout = () => {

    const { setUser } = useAuth();
    const navigate = useNavigate();
    useEffect(() => {
        const doLogout = async () => {
            await axios.post('/api/user/logout');
            setUser(null);
            navigate('/login');
        }
        doLogout();

    }, [])
    return <></>
}

export default Logout;