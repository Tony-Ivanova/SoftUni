import React from 'react'
import styles from './index.module.css'

const Title = ({ title }) => {
    return (
        <div className={styles.container}>
            <h1 className={styles.title}>{title}</h1>
        </div>
    )
}

export default Title