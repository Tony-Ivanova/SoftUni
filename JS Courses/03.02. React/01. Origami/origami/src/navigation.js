import React, { useContext } from 'react'
import {
    Routes,
    Route
} from 'react-router-dom'

import Publications from './pages/publications'
import ShareThoughtsPage from './pages/share-thoughts'
import RegisterPage from './pages/register'
import LoginPage from './pages/login'
import ProfilePage from './pages/profile'
import ErrorPage from './pages/error'
import UserContext from './Context'

const Navigation = () => {

    const context = useContext(UserContext)
    const loggedIn = context.user && context.user.loggedIn

    return (
        <Routes>
            <Route path="/" exact element={<Publications/>} />
            <Route path="/share" element={loggedIn ? <ShareThoughtsPage/> : <LoginPage/>}/>
            <Route path="/register" element={loggedIn ? <ShareThoughtsPage/> : <RegisterPage/>}/>
            <Route path="/login"  element={loggedIn ? <ProfilePage/> : <LoginPage/>}/>
            <Route path="/profile/:userid" element={loggedIn ? <ProfilePage/> : <LoginPage/>}/>
            <Route component={ErrorPage} />
        </Routes>
    )
}

export default Navigation