import React, { useContext, useEffect } from 'react';
import PropTypes from 'prop-types';
import styled, { css } from 'styled-components';
import { MenuContext } from '../context/navState';
import Login from '../pages/login'
import MainMenu from './mainMenu';


const Menu = styled.nav`
  position: absolute;
  top: 0px;
  left: 0px;
  bottom: 0px;
  z-index: 293;
  display: block;
  width: 400px;
  max-width: 100%;
  margin-top: 0px;
  padding-top: 100px;
  padding-right: 0px;
  align-items: stretch;
  background-color: #3A5431;
  transform: translateX(-100%);
  transition: all 0.3s cubic-bezier(0.645, 0.045, 0.355, 1);

  ${props =>
    props.open &&
    css`
      transform: translateX(0);
    `}
`;

export const MenuLink = styled.a`
  position: relative;
  display: block;
  text-align: left;
  max-width: 100%;
  padding-top: 25px;
  padding-bottom: 25px;
  padding-left: 16%;
  background-position: 88% 50%;
  background-size: 36px;
  background-repeat: no-repeat;
  transition: background-position 300ms cubic-bezier(0.455, 0.03, 0.515, 0.955);
  text-decoration: none;
  color: #fff;
  font-size: 32px;
  line-height: 120%;
  font-weight: 500;

  :hover {
    background-position: 90% 50%;
  }
`;

export const SideMenu = ({ children }) => {
  const { isMenuOpen } = useContext(MenuContext);

  return <Menu open={isMenuOpen}>{children}</Menu>;
};

SideMenu.propTypes = {
  children: PropTypes.node,
};

SideMenu.defaultProps = {
  children: (
    <>
      <MenuLink href="/mark">Mark the enemy</MenuLink>
      <MenuLink href="/message">Important message</MenuLink>
  

      <MenuLink href=""></MenuLink>
      <MenuLink href=""></MenuLink>
      <MenuLink href=""></MenuLink>
      <MenuLink href=""></MenuLink>
      <MenuLink href=""></MenuLink>


      <MenuLink href="/admin">Admin panel</MenuLink>
      <MenuLink href="/userLobby">Lobby</MenuLink>
      <MenuLink href="/login">Aitorization</MenuLink>
      <MenuLink href="/about">About</MenuLink>
    </>
  ),
};