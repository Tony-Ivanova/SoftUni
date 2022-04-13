import React from 'react'
import PageLayout from '../page-layout'
import Title from '../../components/title'
import Origamis from '../../components/origamis'

import styles from './index.module.css'


const Publications = () => {

  return (
    <PageLayout>
      <Title title="Publications" />
      <Origamis/>
    </PageLayout>
  )
}

export default Publications