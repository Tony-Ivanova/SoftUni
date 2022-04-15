import React, {  useState, useContext  } from 'react'
import Title from '../../components/title'
import SubmitButton from '../../components/button/submit-button'
import styles from './index.module.css'
import PageLayout from '../../components/page-layout'
import Input from '../../components/input'
import authenticate from '../../utils/authenticate'
import UserContext from '../../Context'
import { useNavigate } from 'react-router-dom'


const RegisterPage = () => {

    const [username, setUsername] = useState('')
    const [password, setPassword] = useState('')
    const [rePassword, setRePassword] = useState('')
    const context = useContext(UserContext)
    const navigate = useNavigate()


    const handleSubmit = async (event) => {
        event.preventDefault()
      
        await authenticate('http://localhost:9999/api/user/register', {
            username,
            password,
            rePassword
        }, (user) => {
            context.logIn(user)
            navigate('/')
        }, (e) => {
            console.log('Error', e)
        })
    }

    return (
        <PageLayout>
            <form className={styles.container} onSubmit={handleSubmit}>
                <Title title="Register" />
                <Input
                    value={username}
                    onChange={(e) => setUsername(e.target.value)}
                    label="Username"
                    id="username"
                />
                <Input
                    type="password"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                    label="Password"
                    id="password"
                />
                <Input
                    type="password"
                    value={rePassword}
                    onChange={(e) => setRePassword(e.target.value)}
                    label="Re-Password"
                    id="re-password"
                />

                <SubmitButton title="Register" />
            </form>
        </PageLayout>
    )
}

export default RegisterPage