import React from 'react'
import Title from '../../components/title'
import Origamis from '../../components/origamis'
import PageLayout from '../page-layout'
import SubmitButton from '../../components/button/submit-button'


import styles from './index.module.css'

const ShareThoughtsPage = () => {
  return (
    <PageLayout>
      <Title title="Share your thoughts..." />
      <div className={styles.container}>
        <div>
          <textarea className={styles.textarea} defaultValue="Publication..."/>
        </div>
        <div>
          <SubmitButton title="Post" />
        </div>
      </div>
      <Origamis length='3'/>
    </PageLayout >
  )
}

export default ShareThoughtsPage;
