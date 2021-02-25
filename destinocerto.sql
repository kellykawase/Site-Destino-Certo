-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 15-Fev-2021 às 08:06
-- Versão do servidor: 10.4.11-MariaDB
-- versão do PHP: 7.3.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `destinocerto`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `pacoteturistico`
--

CREATE TABLE `pacoteturistico` (
  `IdP` int(11) NOT NULL,
  `Nome` varchar(90) NOT NULL,
  `Origem` varchar(90) NOT NULL,
  `Destino` varchar(90) NOT NULL,
  `Saida` date NOT NULL,
  `Retorno` date NOT NULL,
  `Atrativos` varchar(90) NOT NULL,
  `usuario` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `pacoteturistico`
--

INSERT INTO `pacoteturistico` (`IdP`, `Nome`, `Origem`, `Destino`, `Saida`, `Retorno`, `Atrativos`, `usuario`) VALUES
(1, 'Cidade do Rio de Janeiro', 'Vitória-ES', 'Rio de Janeiro-RJ', '2021-03-06', '2021-03-10', 'Cristo Redentor,Pão de Açucar e Arcos da Lapa', 1),
(2, 'Cidade de Salvador', 'Vitória-ES', 'Salvador-BA', '2021-11-05', '2021-11-10', 'Pelourinho, Elevador Lacerda e Igreja de São Francisco', 2),
(3, 'Cidade de Natal', 'Vitória-ES', 'Natal-RN', '2021-05-07', '2021-05-13', 'Dunas de Genipapu, Parrachos de Maracajaú e Praias de Pipa', 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuario`
--

CREATE TABLE `usuario` (
  `Id` int(11) NOT NULL,
  `Nome` varchar(90) NOT NULL,
  `DataNascimento` date NOT NULL,
  `Login` varchar(90) NOT NULL,
  `Senha` varchar(90) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `usuario`
--

INSERT INTO `usuario` (`Id`, `Nome`, `DataNascimento`, `Login`, `Senha`) VALUES
(1, 'Kelly Kawase', '1985-11-11', 'kellykawase', '123'),
(2, 'Jesus Cristo', '2021-02-09', 'jesuscristo', '123');

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `pacoteturistico`
--
ALTER TABLE `pacoteturistico`
  ADD PRIMARY KEY (`IdP`),
  ADD KEY `usuario` (`usuario`);

--
-- Índices para tabela `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `pacoteturistico`
--
ALTER TABLE `pacoteturistico`
  MODIFY `IdP` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT de tabela `usuario`
--
ALTER TABLE `usuario`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `pacoteturistico`
--
ALTER TABLE `pacoteturistico`
  ADD CONSTRAINT `pacoteturistico_ibfk_1` FOREIGN KEY (`usuario`) REFERENCES `usuario` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
