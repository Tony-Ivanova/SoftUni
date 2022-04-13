import React from 'react'
import styles from './submit-button.module.css'

const SubmitButtom = ({ title }) => {
    return (
        <div className={styles.container}>
            <button className={styles.submit}>{title}</button>
        </div>
    )
}

export default SubmitButtom