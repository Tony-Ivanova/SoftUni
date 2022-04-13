import React, { Component } from 'react'
import styles from './index.module.css'
import Input from '../../components/input'

import SubmitButtom from '../../components/button/submit-button'
import Title from '../../components/title'
import PageLayout from '../page-layout'

class RegisterPage extends Component {

    constructor(props) {
        super(props)

        this.state = {
            email: '',
            password: '',
            repassword: ''
        }
    }


    onChange = (event, type) => {
        const newState = {}
        newState[type] = event.target.value

        this.setState(newState)
    }


    render() {

        const {
            email,
            password,
            repassword
        } = this.state;

        return (
            <PageLayout>
                <div className={styles.container}>
                    <Title title='Register' />
                    <Input
                        value={email}
                        onChange={(e) => this.onChange(e, 'email')}
                        label="Email"
                        id="email"
                    />
                    <Input
                        value={password}
                        onChange={(e) => this.onChange(e, 'password')}
                        label="Password"
                        id="password"
                    />
                    <Input
                        value={repassword}
                        onChange={(e) => this.onChange(e, 'repassword')}
                        label="Repassword"
                        id="repassword"
                    />

                    <SubmitButtom title="Register" />
                </div>
            </PageLayout >
        )
    }
}

export default RegisterPage