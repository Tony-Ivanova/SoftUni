import React from 'react'
import Link from '../link'
import styles from './index.module.css'
import logo from '../../images/white-origami-bird.png'
import getNavigation from '../../utils/navigation'


const Header = () => {
    const links = getNavigation();
    return (
        <header className={styles.navigation}>
            <img className={styles.logo} src={logo} alt="Logo" />
            {
                links.map(nav => {
                    return (
                        <Link key={nav.title} href={nav.link} title={nav.title} type="header" />
                    )
                })
            }
        </header>
    )
}

export default Header