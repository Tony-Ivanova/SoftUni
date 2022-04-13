import React from 'react'
import styles from './index.module.css'
import image from '../../images/blue-origami-bird.png'

const Origami = ({ description, author, index }) => {
    return (
        <div className={styles.container}>
            <img className={styles.image} src={image} alt="Logo"/>
            <p className={styles.description}>
                <span>{index}</span>
                {description}
            </p>
            <div className={styles["container div"]}>
                <small>Author:</small>
                <span className={styles.user}>{author.username}</span>
            </div>
        </div>
    )
}

export default Origami