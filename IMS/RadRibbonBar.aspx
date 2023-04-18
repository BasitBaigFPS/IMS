<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RadRibbonBar.aspx.cs" Inherits="IMS.RadRibbonBar" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns='http://www.w3.org/1999/xhtml'>
<head>
    <title>ASP.NET RibbonBar Demo - Items</title>
</head>
 
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
    <telerik:RadSkinManager ID="QsfSkinManager" runat="server" ShowChooser="true" />
    <telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" DecoratedControls="All" EnableRoundedCorners="false" />
 
     <div class="qsf-demo-canvas">
          <telerik:RadRibbonBar ID="RadRibbonBar1" runat="server" SelectedTabIndex="3" OnButtonClick="RadRibbonBar1_ButtonClick" OnApplicationMenuItemClick="RadRibbonBar1_ApplicationMenuItemClick" OnButtonToggle="RadRibbonBar1_ButtonToggle" OnMenuItemClick="RadRibbonBar1_MenuItemClick" OnSelectedTabChange="RadRibbonBar1_SelectedTabChange" OnInit="RadRibbonBar1_Init" OnLoad="RadRibbonBar1_Load">

               <telerik:RibbonBarTab Text="Setup" Value="Setup">

                    <telerik:RibbonBarGroup Text="Stores" Value="Stores">
                         <Items>
                              <telerik:RibbonBarButton Size="Large" Text="Store" ImageUrl="images/Store.png" Width="64" Height="64"/>
                         </Items>
                    </telerik:RibbonBarGroup>
                    <telerik:RibbonBarGroup Text="Items" Value="Items">
                         <Items>
                              <telerik:RibbonBarButtonStrip>
                                   <Buttons>
                                        <telerik:RibbonBarToggleButton Size="Small" Text="Category" ImageUrl="icons/itemIcon.gif" />
                                        <telerik:RibbonBarToggleButton Size="Small" Text="SubCategory" ImageUrl="icons/itemIcon.gif" />
                                        <telerik:RibbonBarToggleButton Size="Small" Text="ItemHead" ImageUrl="icons/itemIcon.gif" />
                                        <telerik:RibbonBarToggleButton Size="Small" Text="Items" ImageUrl="images/Items.png" Width="64"/>
                                   </Buttons>
                              </telerik:RibbonBarButtonStrip>
                         </Items>
                    </telerik:RibbonBarGroup>
                    <telerik:RibbonBarGroup Text="Vendor">
                         <Items>
                              <telerik:RibbonBarToggleButton Size="Large" Text="Large" ImageUrl="images/Vendor.png" Width="64"/>
                         </Items>
                    </telerik:RibbonBarGroup>

                    <telerik:RibbonBarGroup Text="Location">
                         <Items>
                              <telerik:RibbonBarToggleButton Size="Large" Text="Large" ImageUrl="images/location.png" Width="64"/>
                         </Items>
                    </telerik:RibbonBarGroup>

                    <telerik:RibbonBarGroup Text="Types">
                         <Items>
                              <telerik:RibbonBarToggleButton Size="Large" Text="Large" ImageUrl="icons/itemIcon.gif" Width="64"/>
                         </Items>
                    </telerik:RibbonBarGroup>
               </telerik:RibbonBarTab>


               <telerik:RibbonBarTab Text="Items">
                    <telerik:RibbonBarGroup Text="Buttons">
                         <Items>
                              <telerik:RibbonBarButton Size="Large" Text="Large" ImageUrl="icons/itemIcon.gif" />
                              <telerik:RibbonBarButton Size="Medium" Text="Medium" ImageUrl="icons/itemIcon.gif" />
                              <telerik:RibbonBarButton Size="Small" Text="Small" ImageUrl="icons/itemIcon.gif" />
                         </Items>
                    </telerik:RibbonBarGroup>
                    <telerik:RibbonBarGroup Text="ToggleButtons">
                         <Items>
                              <telerik:RibbonBarToggleButton Size="Large" Text="Large" ImageUrl="icons/itemIcon.gif" />
                              <telerik:RibbonBarToggleButton Size="Medium" Text="Medium" ImageUrl="icons/itemIcon.gif" />
                              <telerik:RibbonBarToggleButton Size="Small" Text="Small" ImageUrl="icons/itemIcon.gif" />
                         </Items>
                    </telerik:RibbonBarGroup>
                    <telerik:RibbonBarGroup Text="ButtonStrip">
                         <Items>
                              <telerik:RibbonBarButtonStrip>
                                   <Buttons>
                                        <telerik:RibbonBarButton ImageUrl="icons/itemIcon.gif" />
                                        <telerik:RibbonBarButton ImageUrl="icons/itemIcon.gif" />
                                        <telerik:RibbonBarButton ImageUrl="icons/itemIcon.gif" />
                                        <telerik:RibbonBarButton ImageUrl="icons/itemIcon.gif" />
                                   </Buttons>
                              </telerik:RibbonBarButtonStrip>
                         </Items>
                    </telerik:RibbonBarGroup>
                    <telerik:RibbonBarGroup Text="ToggleList">
                         <Items>
                              <telerik:RibbonBarToggleList>
                                   <ToggleButtons>
                                        <telerik:RibbonBarToggleButton Size="Large" Text="Large" ImageUrl="icons/itemIcon.gif" />
                                        <telerik:RibbonBarToggleButton Size="Medium" Text="Medium" ImageUrl="icons/itemIcon.gif" />
                                        <telerik:RibbonBarToggleButton Size="Small" Text="Small" ImageUrl="icons/itemIcon.gif" />
                                   </ToggleButtons>
                              </telerik:RibbonBarToggleList>
                         </Items>
                    </telerik:RibbonBarGroup>
               </telerik:RibbonBarTab>

               <telerik:RibbonBarTab Text="DropDown Items">
                    <telerik:RibbonBarGroup Text="SplitButtons">
                         <Items>
                              <telerik:RibbonBarSplitButton Size="Large" Text="Large" ImageUrl="icons/itemIcon.gif">
                                   <Buttons>
                                        <telerik:RibbonBarButton Text="Text" ImageUrl="icons/itemIcon.gif" />
                                        <telerik:RibbonBarButton Text="Text" ImageUrl="icons/itemIcon.gif" />
                                        <telerik:RibbonBarButton Text="Text" ImageUrl="icons/itemIcon.gif" />
                                        <telerik:RibbonBarButton Text="Text" ImageUrl="icons/itemIcon.gif" />
                                   </Buttons>
                              </telerik:RibbonBarSplitButton>
                              <telerik:RibbonBarSplitButton Size="Medium" Text="Medium" ImageUrl="icons/itemIcon.gif">
                                   <Buttons>
                                        <telerik:RibbonBarButton Text="Text" ImageUrl="icons/itemIcon.gif" />
                                        <telerik:RibbonBarButton Text="Text" ImageUrl="icons/itemIcon.gif" />
                                        <telerik:RibbonBarButton Text="Text" ImageUrl="icons/itemIcon.gif" />
                                        <telerik:RibbonBarButton Text="Text" ImageUrl="icons/itemIcon.gif" />
                                   </Buttons>
                              </telerik:RibbonBarSplitButton>
                              <telerik:RibbonBarSplitButton Size="Small" Text="Small" ImageUrl="icons/itemIcon.gif">
                                   <Buttons>
                                        <telerik:RibbonBarButton Text="Text" ImageUrl="icons/itemIcon.gif" />
                                        <telerik:RibbonBarButton Text="Text" ImageUrl="icons/itemIcon.gif" />
                                        <telerik:RibbonBarButton Text="Text" ImageUrl="icons/itemIcon.gif" />
                                        <telerik:RibbonBarButton Text="Text" ImageUrl="icons/itemIcon.gif" />
                                   </Buttons>
                              </telerik:RibbonBarSplitButton>
                         </Items>
                    </telerik:RibbonBarGroup>
                    <telerik:RibbonBarGroup Text="Menu">
                         <Items>
                              <telerik:RibbonBarMenu Size="Large" Text="Large" ImageUrl="icons/itemIcon.gif">
                                   <Items>
                                        <telerik:RibbonBarMenuItem Text="Text" ImageUrl="icons/itemIcon.gif" />
                                        <telerik:RibbonBarMenuItem Text="Text" ImageUrl="icons/itemIcon.gif" />
                                        <telerik:RibbonBarMenuItem Text="Text" ImageUrl="icons/itemIcon.gif" />
                                        <telerik:RibbonBarMenuItem Text="Text" ImageUrl="icons/itemIcon.gif" />
                                   </Items>
                              </telerik:RibbonBarMenu>
                              <telerik:RibbonBarMenu Size="Medium" Text="Medium" ImageUrl="icons/itemIcon.gif">
                                   <Items>
                                        <telerik:RibbonBarMenuItem Text="Text" ImageUrl="icons/itemIcon.gif" />
                                        <telerik:RibbonBarMenuItem Text="Text" ImageUrl="icons/itemIcon.gif" />
                                        <telerik:RibbonBarMenuItem Text="Text" ImageUrl="icons/itemIcon.gif" />
                                        <telerik:RibbonBarMenuItem Text="Text" ImageUrl="icons/itemIcon.gif" />
                                   </Items>
                              </telerik:RibbonBarMenu>
                              <telerik:RibbonBarMenu Size="Small" Text="Small" ImageUrl="icons/itemIcon.gif">
                                   <Items>
                                        <telerik:RibbonBarMenuItem Text="Text" ImageUrl="icons/itemIcon.gif" />
                                        <telerik:RibbonBarMenuItem Text="Text" ImageUrl="icons/itemIcon.gif" />
                                        <telerik:RibbonBarMenuItem Text="Text" ImageUrl="icons/itemIcon.gif" />
                                        <telerik:RibbonBarMenuItem Text="Text" ImageUrl="icons/itemIcon.gif" />
                                   </Items>
                              </telerik:RibbonBarMenu>
                         </Items>
                    </telerik:RibbonBarGroup>
               </telerik:RibbonBarTab>

            <telerik:RibbonBarTab Text="Input Items">
                <telerik:RibbonBarGroup Text="DropDown">
                    <Items>
                        <telerik:RibbonBarDropDown Width="100">
                            <Items>
                                <telerik:RibbonBarListItem Text="item 1" Selected="true" />
                                <telerik:RibbonBarListItem Text="item 2" />
                                <telerik:RibbonBarListItem Text="item 3" />
                                <telerik:RibbonBarListItem Text="item 4" />
                            </Items>
                        </telerik:RibbonBarDropDown>
                    </Items>
                </telerik:RibbonBarGroup>
                <telerik:RibbonBarGroup Text="ComboBox">
                    <Items>
                        <telerik:RibbonBarComboBox Width="100">
                            <Items>
                                <telerik:RibbonBarListItem Text="item 1" Selected="true" />
                                <telerik:RibbonBarListItem Text="item 2" />
                                <telerik:RibbonBarListItem Text="item 3" />
                                <telerik:RibbonBarListItem Text="item 4" />
                            </Items>
                        </telerik:RibbonBarComboBox>
                    </Items>
                </telerik:RibbonBarGroup>
                <telerik:RibbonBarGroup Text="NumericTextBox">
                    <Items>
                        <telerik:RibbonBarNumericTextBox Value="20" Width="100" Suffix=" pt"/>
                    </Items>
                </telerik:RibbonBarGroup>
                <telerik:RibbonBarGroup Text="ColorPicker">
                    <Items>
                        <telerik:RibbonBarColorPicker />
                    </Items>
                </telerik:RibbonBarGroup>
            </telerik:RibbonBarTab>

            <telerik:RibbonBarTab Text="Gallery Items">
                <telerik:RibbonBarGroup Text="Gallery">
                    <Items>
                        <telerik:RibbonBarGallery>
                            <telerik:RibbonBarGalleryCategory Title="Category 1">
                                <telerik:RibbonBarGalleryItem ImageUrl="icons/galleryItem.gif" />
                                <telerik:RibbonBarGalleryItem ImageUrl="icons/galleryItem.gif" />
                                <telerik:RibbonBarGalleryItem ImageUrl="icons/galleryItem.gif" />
                                <telerik:RibbonBarGalleryItem ImageUrl="icons/galleryItem.gif" />
                                <telerik:RibbonBarGalleryItem ImageUrl="icons/galleryItem.gif" />
                                <telerik:RibbonBarGalleryItem ImageUrl="icons/galleryItem.gif" />
                                <telerik:RibbonBarGalleryItem ImageUrl="icons/galleryItem.gif" />
                                <telerik:RibbonBarGalleryItem ImageUrl="icons/galleryItem.gif" />
                                <telerik:RibbonBarGalleryItem ImageUrl="icons/galleryItem.gif" />
                                <telerik:RibbonBarGalleryItem ImageUrl="icons/galleryItem.gif" />
                            </telerik:RibbonBarGalleryCategory>
                            <telerik:RibbonBarGalleryCategory Title="Category 2">
                                <telerik:RibbonBarGalleryItem ImageUrl="icons/galleryItem.gif" />
                                <telerik:RibbonBarGalleryItem ImageUrl="icons/galleryItem.gif" />
                                <telerik:RibbonBarGalleryItem ImageUrl="icons/galleryItem.gif" />
                                <telerik:RibbonBarGalleryItem ImageUrl="icons/galleryItem.gif" />
                                <telerik:RibbonBarGalleryItem ImageUrl="icons/galleryItem.gif" />
                                <telerik:RibbonBarGalleryItem ImageUrl="icons/galleryItem.gif" />
                                <telerik:RibbonBarGalleryItem ImageUrl="icons/galleryItem.gif" />
                                <telerik:RibbonBarGalleryItem ImageUrl="icons/galleryItem.gif" />
                                <telerik:RibbonBarGalleryItem ImageUrl="icons/galleryItem.gif" />
                                <telerik:RibbonBarGalleryItem ImageUrl="icons/galleryItem.gif" />
                            </telerik:RibbonBarGalleryCategory>
                            <telerik:RibbonBarGalleryCategory Title="Category 3">
                                <telerik:RibbonBarGalleryItem ImageUrl="icons/galleryItem.gif" />
                                <telerik:RibbonBarGalleryItem ImageUrl="icons/galleryItem.gif" />
                                <telerik:RibbonBarGalleryItem ImageUrl="icons/galleryItem.gif" />
                                <telerik:RibbonBarGalleryItem ImageUrl="icons/galleryItem.gif" />
                                <telerik:RibbonBarGalleryItem ImageUrl="icons/galleryItem.gif" />
                                <telerik:RibbonBarGalleryItem ImageUrl="icons/galleryItem.gif" />
                                <telerik:RibbonBarGalleryItem ImageUrl="icons/galleryItem.gif" />
                                <telerik:RibbonBarGalleryItem ImageUrl="icons/galleryItem.gif" />
                                <telerik:RibbonBarGalleryItem ImageUrl="icons/galleryItem.gif" />
                                <telerik:RibbonBarGalleryItem ImageUrl="icons/galleryItem.gif" />
                            </telerik:RibbonBarGalleryCategory>
                        </telerik:RibbonBarGallery>
                    </Items>
                </telerik:RibbonBarGroup>
            </telerik:RibbonBarTab>

          </telerik:RadRibbonBar>
     </div>
 
    </form>
</body>
</html>