import React from 'react';
import { Route, Routes } from 'react-router';
import { AuthContextComponent } from './AuthContext';
import Layout from './Layout';
import Signup from './Signup';
import Home from './Home';
import Login from './Login';
import PrivateRoute from './PrivateRoute';
import Logout from './Logout';

const App = () => {
    return (
        <AuthContextComponent>
            <Layout>
                <Routes>
                    <Route exact path='/signup' element={<Signup />} />
                    <Route exact path='/login' element={<Login />} />
                    <Route exact path='/' element={
                        <PrivateRoute>
                            <Home />
                        </PrivateRoute>} />

                    <Route exact path='/logout' element={
                        <PrivateRoute>
                            <Logout />
                        </PrivateRoute>} />
                </Routes>
            </Layout>
        </AuthContextComponent>
    )
}

export default App;