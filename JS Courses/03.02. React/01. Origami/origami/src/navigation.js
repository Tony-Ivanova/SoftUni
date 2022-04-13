import React from 'react'
import {
    BrowserRouter,
    Routes,
    Route
} from 'react-router-dom'

import Publications from './pages/publications'
import ShareThoughtsPage from './pages/share-thoughts'

const Navigation = () => {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<Publications/>} />
                <Route path="/share" element={<ShareThoughtsPage/>} />
            </Routes>
        </BrowserRouter>
    )
}

export default Navigation