import React from 'react'
import {
    BrowserRouter,
    Routes,
    Route
} from 'react-router-dom'
import LoginPage from './pages/login'

import Publications from './pages/publications'
import RegisterPage from './pages/register'
import ShareThoughtsPage from './pages/share-thoughts'

const Navigation = () => {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<Publications/>} />
                <Route path="/share" element={<ShareThoughtsPage/>} />
                <Route path="/login" element={<LoginPage/>} />
                <Route path="/register" element={<RegisterPage/>} />
            </Routes>
        </BrowserRouter>
    )
}

export default Navigation