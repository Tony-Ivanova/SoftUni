import React from 'react'
import Link from '../link'
import styles from './index.module.css'

const Footer = () => {
    return (
        <footer className={styles.container}>
            <div>
                <Link href="#" title="Going to 1" type="header" />
                <Link href="/" title="Going to 2" type="footer" />
                <Link href="/" title="Going to 3" type="footer" />
                <Link href="/" title="Going to 4" type="footer" />
                <Link href="/" title="Going to 5" type="footer" />
                <Link href="/" title="Going to 6" type="footer" />
            </div>
            <p className={styles["container p"]}>
                Software University 2019
            </p>
        </footer>
    )
}


export default Footer;