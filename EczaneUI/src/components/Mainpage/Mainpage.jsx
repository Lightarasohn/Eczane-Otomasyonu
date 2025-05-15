import { Layout, Menu } from "antd";
import "./Mainpage.css";
import { useState } from "react";
import MainpageContent from "./MainpageContent";
import Sider from "antd/es/layout/Sider";
import { Content, Footer, Header } from "antd/es/layout/layout";
import eczaneLogo from "../../assets/eczane-seeklogo.png";
import IlacAdd from "../Ilac/IlacAdd";
import SatisButton from "../Satis/SatisButton";
import RaporButton from "../Rapor/RaporButton";

const Mainpage = () => {
  const [page, setPage] = useState("1");
  const [ilaclar, setIlaclar] = useState([]);
  const [checkedList, setCheckedList] = useState([]);
  const [satislar, setSatislar] = useState([]);
  const [raporlar, setRaporlar] = useState([]);

  const items = [
    { key: "1", label: "Ana Sayfa" },
    { key: "2", label: "İlaçlar" },
    { key: "3", label: "Satışlar" },
    { key: "4", label: "Raporlama" },
  ];

  const handleMenuClick = (e) => {
    setPage(e.key);
    console.log(e.key);
  };

  const setHeader = () => {
    switch (page) {
      case "2":
        return (
          <>
            <IlacAdd setIlaclar={setIlaclar} ilaclar={ilaclar} />
            <SatisButton
              checkedList={checkedList}
              satislar={satislar}
              setSatislar={setSatislar}
            />
          </>
        );
      case "4":
        return(
          <>
            <RaporButton satislar={satislar} raporlar={raporlar} setRaporlar={setRaporlar}></RaporButton>
          </>
        );
    }
  };

  return (
    <Layout className="mainpage-outside-layout">
      <Sider className="mainpage-sider" width={200} theme="dark">
        <div className="logo">
          <img
            src={eczaneLogo}
            alt="Logo"
            style={{
              height: "54px",
              width: "54px",
            }}
          />
        </div>
        <div className="demo-logo-vertical" />
        <Menu
          theme="dark"
          mode="inline"
          defaultSelectedKeys={["1"]}
          items={items}
          onClick={handleMenuClick}
        />
      </Sider>
      <Layout className="mainpage-inside-layout">
        <Header
          className="mainpage-inside-header"
          style={{
            display: "flex",
            alignItems: "center",
            justifyContent: "center",
            gap: "10px",
          }}
        >
          {setHeader()}
        </Header>
        <Content
          className="mainpage-inside-content"
          style={{ margin: "24px 16px 0" }}
        >
          <MainpageContent
            pageKey={page}
            ilaclar={ilaclar}
            setIlaclar={setIlaclar}
            checkedList={checkedList}
            setCheckedList={setCheckedList}
            satislar={satislar}
            setSatislar={setSatislar}
            raporlar={raporlar}
            setRaporlar={setRaporlar}
          />
        </Content>
        <Footer
          className="mainpage-inside-footer"
          style={{ textAlign: "center" }}
        >
          Ant Design ©{new Date().getFullYear()} Created by Ant UED
        </Footer>
      </Layout>
    </Layout>
  );
};

export default Mainpage;
